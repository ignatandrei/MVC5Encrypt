# MVC5Encrypt
Encrypt / decrypt query string parameters with MVC 5

3 Steps to use :

1. Install  MVC5Encrypt from Nuget: Install-Package MVC5Encrypt

2. Modify

<p>&lt;a href='@Url.Action(&quot;TestEncrypt&quot;, new {id=7, a = 1, b = &quot;asd&quot; })'&gt;Test&lt;/a&gt;</p>

into 

<p>&lt;a href='@Url.ActionEnc(&quot;mySecret&quot;, &quot;TestEncrypt&quot;, new {id=7, a = 1, b = &quot;asd&quot; })'&gt;Test&lt;/a&gt;</p>
( Add as first line in the view:

@using MVCEncrypt;
)

3. Add to the action the MVCDecryptFilterAttribute

[MVCDecryptFilter(secret = &quot;mySecret&quot;)] 


Demo at http://mvc5encrypt.apphb.com/ 


NuGet at https://www.nuget.org/packages/MVC5Encrypt/


Sources on GitHub : https://github.com/ignatandrei/MVC5Encrypt

More details at Wiki https://github.com/ignatandrei/MVC5Encrypt/wiki

Video at https://youtu.be/FA-sTM6cf5w

Contact at my blog http://msprogrammer.serviciipeweb.ro/2017/03/20/mvc-5-encrypt-parameters/
