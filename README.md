# this-task
> establishing connection between a local react app and a unity project.
> ``` HttpListener class ``` makes our Unity application to act as a web server.
> in the ```Start method ```, the listener listens for HTTP requests on port 3001, ```BeginGetContext``` sets up the server to handle incoming requests.
>```OnRequest method ``` handles incoming HTTP requests,It checks the type of request "POST", reads the data sent by the client,converts the JSON data sent in the request to a ```ReceivedData```.

