# BestPracticesMCP - Model Context Protocol (MCP) Server

## Overview

This is a Model Context Protocol (MCP) server implementation built with .NET 8.0. 

This can be used to access coding best practices for various programming languages.

More information [https://markharrison.io/doc-mcp](<https://markharrison.io/doc-mcp>)

Different projects are provided to support:

- STDIO
- Http Streamable - Docker Image
- Http Streamable with OAuth authentication/authorization - Docker Image
- SSE - Azure Function App

## Example 

```text
What are the best practices for writing Python code?
```

## Configuration STDIO

### VSCode config 

Filename:  .vscode\mcp.json

```JSON
{
    "servers": {
        "bestpracticesserver": {
            "type": "stdio",
            "command": "dotnet",
            "args": [
                "run",
                "--project",
                "c:/dev/BestPracticesMCP/BestPracticesMCP/BestPracticesMCP.csproj"
            ]
        }
    }
}
```

## Configuration HTTP - Docker 

### Build Docker file 

```
cd <projectroot>
docker build -f bestpracticesmcp-http/Dockerfile -t bestpracticesmcp-http:latest .
docker images
```

### Run Docker file 

```
docker run -p 3000:8080 -p 3001:8081 -d bestpracticesmcp-http:latest
```

### VSCode config

Filename:  .vscode\mcp.json

 ```JSON
{
    "servers": {
        "bestpracticesserver": {
            "type": "http",
            "url": "http://localhost:3000"
        }
    }
}
```




## Test

```
$env:DANGEROUSLY_OMIT_AUTH = 'true'
npx @modelcontextprotocol/inspector
```

![screenshot](./docs/scrn4.png)
