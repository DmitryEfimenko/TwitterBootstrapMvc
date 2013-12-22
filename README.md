TwitterBootstrapMVC
===================

![TwitterBootstrapMvc](https://github.com/DmitryEfimenko/TwitterBootstrapMvc/blob/master/TwitterBootstrapMVC/TwitterBootstrapMVC.png?raw=true)

Fluent implementation of ASP.NET-MVC HTML helpers for Twitter Bootstrap.

This project aims to help .NET MVC developers to write twitter bootstrap related code faster. If you'd like a jump start, watch [this 6 minutes video](http://www.youtube.com/watch?v=6LpWMl5D2i4) explaining what TwitterBootstrapMVC does.

**!IMPORTANT:** This version does not have all the latest features including support for Twitter Bootstrap 3. I've continued working on this project in a commercial version, the documentation for which you can see at [TwitterBootstrapMVC.com](https://www.twitterbootstrapmvc.com).
However, I'm leaving the code for it here for the benefit of the community.

# Documentation:
Visit [TwitterBootstrapMVC.com](https://www.twitterbootstrapmvc.com) to see all the relevant information about this library.

NuGet package
package ID: **TwitterBootstrapMVC**


*Known Issue:*
You might get the following error when installing TwitterBootstrapMVC using NuGet:
```
error: could not install package 'portable.licensing 1.1.0' you are trying to install this package
into a project that targets '.netframework, version=v4.0', but the package does not contain any assembly
references that are compatible with that framework
```
In order to fix it, make sure you have latest NuGet since PCL support was added in NuGet 2.5 or 2.5.* 

# Submitting Issues:
* Include your current code that is relevant to your situation. That probably will be code from controller, model anda a view.
* Be sure to include html that you are looking for.
* Provide link to Bootstrap docs if you think that BMVC does not have support for some of Bootstra's functionality
* Be sure to describe clearly what does not work and what do you expect to get.
