# BestPracticesMCP - Model Context Protocol (MCP) Server

## Overview

This is a Model Context Protocol (MCP) server implementation built with .NET 8.0. 

This can be used to access coding best practices for various programming languages.

More information [https://markharrison.io/doc-mcp](<https://markharrison.io/doc-mcp>)

## Example 

```text
What are the best practices for writing Python code?
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
