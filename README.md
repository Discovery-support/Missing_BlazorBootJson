# Missing_BlazorBootJson

This project runs locally, but fails to correctly publish (via Web Deploy). 
The project appears to skip the creation of _framework/blazor.boot.json as well as its dependent DLLs.
**The upgrade to Blazor 3.2.0 was responsible for this issue appearing.**

Is there a workaround for this issue?  (Deleting Obj and Bin directories in all projects fails to resolve this.)

To reproduce:

Publish Project (I used Web Deploy) and _framework/blazor.boot.json will be missing

Browse to Published Website

Chrome error results:

Failed to load resource: the server responded with a status of 404 (Not Found) _framework/blazor.boot.json:1
Uncaught (in promise) ReferenceError: Module is not defined at blazor.webassembly.js:1
