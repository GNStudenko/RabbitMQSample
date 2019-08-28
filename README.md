# RabbitMQSample
## Requirements
You will need to have RabbitMQ installed in your local machine with the service running.

## Instructions to run
1. Set the **Producer** project as the StartUp project and run it a couple of times, by doing this you will be sending messages to the Queue.

1. Check the RabbitMQ dashboard to see all the messages that are currently under the TestQueue.

1. Set the **Receiver** project as the StartUp project and run it, by doing this you will be consuming all the messages in the TestQueue.
