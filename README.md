# TimeTracker

Keep track of your time with this simple web application.

## Prerequisites

- Configure IIS Express
 
## Projects

### TimeTracker.WebApplication

The user interface!

### TimeTracker.Specifications

TimeTracker.Specifications contains a specification and end-to-end (system) test for every feature of the TimeTracker.WebApplication.

In other words. Have a new feature for TimeTracker.WebApplication? Add a specification to the Feature folder first.

## IIS Express Configuration

TimeTracker.Specifications requires IIS Express to be configured so the WebApplication can be served via port 80 & 443. An added advantage is 
WebApplication testing via a network attached device is possible. 

See [Scott Hanselman's](http://www.hanselman.com/blog/WorkingWithSSLAtDevelopmentTimeIsEasierWithIISExpress.aspx) excellent write up on how to do this. 

My brief instructions are as follows:

- Run all commands from Administrator command prompt.
- Replace timmurphy2010 with your computer name.

    cd C:\Users\Tim

    netsh http add urlacl url=http://timmurphy2010:80/ user=everyone

    netsh firewall add portopening TCP 80 IISExpressWeb enable ALL

    "C:\Program Files (x86)\IIS Express\appcmd.exe" set site /site.name:TimeTracker.WebApplication /+bindings.[protocol='http',bindingInformation='*:80:timmurphy2010']
    
    "C:\Program Files (x86)\Windows Kits\8.1\bin\x64\makecert" -r -pe -n "CN=TIMMURPHY2010" -b 01/01/2000 -e 01/01/2036 -eku 1.3.6.1.5.5.7.3.1 -ss my -sr localMachine -sky exchange -sp "Microsoft RSA SChannel Cryptographic Provider" -sy 12

See [Scott's](http://www.hanselman.com/blog/WorkingWithSSLAtDevelopmentTimeIsEasierWithIISExpress.aspx) post to get the certificate thumb print.

    netsh http add sslcert ipport=0.0.0.0:443 appid={214124cd-d05b-4309-9af9-9caa44b2b74a} certhash=YOURCERTHASHHERE

    netsh http add urlacl url=https://timmurphy2010:443/ user=Everyone
    
    "C:\Program Files (x86)\IIS Express\appcmd.exe" set site /site.name:TimeTracker.WebApplication /+bindings.[protocol='https',bindingInformation='*:443:timmurphy2010']

Trust the certificate as per Scott's instructions.