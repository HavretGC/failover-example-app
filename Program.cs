using System;
using Apache.NMS;
using Apache.NMS.AMQP;
using GainCapital.NMS;
using NLog;
using Spring.Messaging.Nms.Connections;
using Spring.Messaging.Nms.Core;
using Spring.Messaging.Nms.Listener;

namespace FailoverExampleApp
{
    static class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static readonly string DestinationName = "myTestDestination";

        static void Main(string[] args)
        {
            Tracer.Trace = new NLogAdapter();

            var brokerUri = "failover:(amqp://127.0.0.1:5672,amqp://127.0.0.1:5673)" +
                            "?failover.initialReconnectDelay=1000" +
                            "&failover.reconnectDelay=1000" +
                            "&failover.maxReconnectAttempts=10";
            var connectionFactory = new NmsConnectionFactory(brokerUri);
            var simpleMessageListenerContainer = new SimpleMessageListenerContainer
            {
                ConnectionFactory = connectionFactory,
                DestinationName = DestinationName,
                MessageListener = new MessageListener()
            };
            // start listener
            simpleMessageListenerContainer.AfterPropertiesSet();
            
            var cachingConnectionFactory = new CachingConnectionFactory(connectionFactory);
            var nmsTemplate = new NmsTemplate(cachingConnectionFactory)
            {
                DefaultDestinationName = DestinationName,
            };

            while (true)
            {
                Logger.Info("Enter your message.");
                var text = Console.ReadLine();
                nmsTemplate.SendWithDelegate(session => session.CreateTextMessage(text));
            }
        }
    }

    public class MessageListener : IMessageListener
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void OnMessage(IMessage message)
        {
            switch (message)
            {
                case ITextMessage textMessage:
                    Logger.Info($"Received message: {textMessage}");
                    break;
                default:
                    Logger.Error("Received unknown message.");
                    break;
            }
        }
    }
}