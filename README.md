# SAML-implementation
![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 002](https://github.com/Hasannemer/SAML-implementation/assets/95302818/de15b746-62ed-4a39-85a5-a76a5dacf718)


A complete guide to understand and implement the SAML security standard 

## <a name="_toc321147149"></a><a name="_toc318188227"></a><a name="_toc318188327"></a><a name="_toc318189312"></a><a name="_toc321147011"></a>SAML SECURITY STANDARD

` ` MOHAMMAD HASAN NEMER | WEB APPLICATION SECURITY |5-12-2023


# Table of Contents
[1. Introduction](#_toc153109162)

[1.1 AIM OF THE PROJECT](#_toc153109163)

[1.2 WHAT IS SAML?](#_toc153109164)

[2. OVERVIEW OF SAML](#_toc153109165)

[2.1 Why SAML?](#_toc153109166)

[2.2 How is SAML used with web applications	](#_toc153109167)

[2.3 Components of SAML](#_toc153109168)

[3. SAML FLOW](#_toc153109169)

[3.1 User/agent scenario	](#_toc153109170)

[3.2 IdP/SP scenario	](#_toc153109171)
	
[3.3 Trust scenario ](#_toc153109172)

[3.4 Metadata	](#_toc153109173)

[3.5 SP-Initiation Flow	](#_toc153109174)

[4.Potential Security Risks	](#_toc153109175)

[4.1 XML injection	](#_toc153109176)

[4.2 Affected Fields	](#_toc153109177)

[5.Setup and Configuration	](#_toc153109178)

[5.1 Requirements:	](#_toc153109179)

[5.2 Implementation	](#_toc153109180)

[5.2.1 Create ASP.NET Core Web App	](#_toc153109181)

[5.2.2 Configure a view to display user claims	](#_toc153109182)

[5.2.3 Install the RSK library	](#_toc153109183)

[5.2.4 Initial configuration	](#_toc153109184)

[5.2.5 IdP configuration	](#_toc153109185)

[5.2.6 Final Configuration	](#_toc153109186)

[5.2.7 Assign Users	](#_toc153109187)

[5.3 DEMO	](#_toc153109188)

[6. Conclusion	](#_toc153109189)

[To sum up	](#_toc153109190)

[FINAL WORDS	](#_toc153109191)

[7. References	](#_toc153109192)



# <a name="_toc153109162"></a>1.Introduction
## <a name="_toc153109163"></a>1.1 AIM OF THE PROJECT
This project aims to provide a comprehensive understanding of the SAML (Security Assertion Markup Language) security standard, by examining the main concepts underlying this authentication standard. Including its workflow, strengths, weaknesses, and potential vulnerabilities. Additionally, this project includes a step-by-step implementation guide, offering practical insights into deploying SAML effectively within a web application environment.


## <a name="_ref153041758"></a><a name="_toc153109164"></a>1.2 WHAT IS SAML?
SAML is an open standard used for authentication it first started in 2001, the version 2.0 came in 2005. Based upon the XML format, web applications use SAML to transfer authentication data between two parties - the identity provider (IdP) and the service provider (SP). SAML works by exchanging user information, such as logins, authentication state, identifiers, and other relevant attributes between the identity and service provider. As a result, it simplifies and secures the authentication process as the user only needs to log in once with a single set of authentication credentials using the SSO (single sign on) concept. So, when the user tries to access a site, the identity provider passes the SAML authentication to the service provider, who then grants the user entry. 


# <a name="_toc153109165"></a>2.OVERVIEW OF SAML
## <a name="_toc153109166"></a>2.1WHY SAML?
SAML is widely adopted enterprise solution it provides: 

- Improved user experience by sign in once to access multiple web apps.
- Speed up the authentication by remembering one set of credentials  
- Less calls for IT technical to change/rest passwords 
- Server provider doesn’t need to store user credentials because the identity provider stores all login information
- Service provider don’t need to worry about the authentication of accounts because it is IdP’s responsibility that provide extra layer of security by implementing MFA 


## <a name="_toc153109167"></a>2.2 HOW IS SAML USED WITH WEB APPLICATIONS
SAML protocol has three entities: 

1. User agent (user’s web browser) 
1. Service provider SP, our web application (RSK is used in this project)
1. The identity provider IdP (Okta is used in this project)

**Identity Providers (IdP)** provide online resources to give authentication to end users over the network. Sometimes these are also called an identity Service Provider or an Identity Assertion provider.

**Service Providers (SP)** provide resources to an end user for Single Sign On (SSO).

A trust relationship is established between IdP and SP 


## <a name="_toc153109168"></a>2.3 COMPONENTS OF SAML
The main components of SAML are:

1. **Assertions** which defines the structure and content of the information being transferred
1. A **binding** defines the communication protocols (such as HTTP or SOAP) over which the SAML protocol can be transported
1. How an assertion is requested by, or pushed to, a service provider is defined as a request/response **protocol** encoded in its own structural guidelines
1. Together, these three components create a **profile** (such as Web Browser Artifact or Web Browser POST)
1. **Metadata** defines how configuration information shared between two communicating entities is structured. For instance, an entity's support for specific SAML bindings, identifier information, and public key information is defined in the metadata. The structure of the metadata is based on the SAML v2 metadata schema. The location of the metadata is defined by Domain Name Server (DNS) records.

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 008](https://github.com/Hasannemer/SAML-implementation/assets/95302818/0a3e848a-ed65-41f0-a932-d2389b3d24f5)


<a name="_toc153109217"></a>


# <a name="_toc153109169"></a>3.SAML FLOW

## <a name="_toc153109170"></a>3.1 USER/SP SCENARIO
1. The user tries to access the SP must first authenticate to the IdP
1. If the user manages to successful authenticate 
1. The IdP generates a SAML assertion 
1. The assertion is sent to the application 
1. since the application trust the IdP
1. the user now is allowed to access the application
1. since user is authenticated into IdP user can Single Sign On to other apps that are in the same area of trust 

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 009](https://github.com/Hasannemer/SAML-implementation/assets/95302818/bca47548-453a-46da-b3a0-ac4306fb8666)


<a name="_toc153109218"></a>



## <a name="_toc153109171"></a>3.2 IDP/SP SCENARIO 
1. The IdP know about our users and their attributes, and the SP has its own knowledge about the users 
1. The IdP generates an assertion and populate it with user identifier, sign it and send it to the SP. Note that both sides must agree on the SAML configuration for the user identifier for correct mapping in the SP side.
1. The SP validate the assertion, and reads user identifier, allowing access to that user.

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 010](https://github.com/Hasannemer/SAML-implementation/assets/95302818/2b4441ca-c117-4e65-94a5-8d30173a8168)

<a name="_toc153109219"></a>


## <a name="_toc153109172"></a>3.3 TRUST SCENARIO
- The configuration for integration is critical to successfully establish SAML federation, these configurations can be entered manually to SP, or IdP as XML metadata file that contains the settings and the certificate of system 
- These files now can be exchanged to configure federation 

Trust is established between the SP and IdP

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 011](https://github.com/Hasannemer/SAML-implementation/assets/95302818/1cf11c45-5e83-4c6b-ab35-50cabbe4dd1f)
<a name="_toc153109220"></a>


## <a name="_toc153109173"></a>3.4 METADATA 
The metadata file contains the format of the user identifier called the NAMEID format which is standardized 

![xml](https://github.com/Hasannemer/SAML-implementation/assets/95302818/2245d870-8b4c-422e-b900-f9ca108d16e8)

The metadata contains the certificate that validate the assertion 

The entity ID that indicate sender/reciever

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 014](https://github.com/Hasannemer/SAML-implementation/assets/95302818/6eec4aaa-9e3f-43f7-b1c2-5c2bb8bf2577)



## <a name="_toc153109174"></a>3.5 SP-INITIATION FLOW
1. The user reaches the SP 
1. User is directed to IdP using request for authentication message
1. The user asks the IdP for authentication 
1. If user is validated the IdP generates the SAML assertion 
1. The assertion is sent to user 
1. The assertion then is sent from user to SP 
1. The session starts 

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 015](https://github.com/Hasannemer/SAML-implementation/assets/95302818/2722447f-1f1b-49ef-be36-0f018c842502)

# <a name="_toc153109175"></a>4.Potential Security Risks
## <a name="_toc153109176"></a>4.1 XML INJECTION 
The main issue is if the user input is directly included in XML messages and sent to the backend server without being encoded, filtered and sanitized. The attacker then can inject additional XML, and modify the request.

This attack is mainly done at the IdP side if the used libraries are not strict to user input, that could insert the data into the template string (that the SAML XML is built from) using a template language, regex match/replace, or simple concatenation.



## <a name="_toc153109177"></a>4.2 AFFECTED FIELDS   
When constructing SAML responses, the identity provider often includes user-controlled data like SAML **NameID** (identifying the user) and additional attributes requested by service providers (e.g., full name, phone number).

Less evident fields, typically sourced from the SAML request, may also affect SAML responses:

**InResponseTo** Attribute: Contains the SAML request ID, commonly included in SAML responses, making it a prime target for probing XML injection vulnerabilities.

**Issuer** Field: Identifies the issuer of the SAML request, potentially included in the Audience field of SAML assertions.

**IssueInstant**: Indicates the time of SAML request generation, possibly included in assertion conditions like **NotBefore**.

**Destination** Field: Specifies the SAML request endpoint, which might be used in the Audience element of assertions.

In some instances, external data sources might influence SAML responses. For example, an unauthenticated client's SAML request might trigger a server redirect to a login page with a GET parameter containing the request's ID. Modifying this ID parameter during login could enable injecting XML into the resulting SAML response.

For more information, see https://research.nccgroup.com/2021/03/29/saml-xml-injection/


# <a name="_toc153109178"></a>5.Setup and Configuration 
## <a name="_toc153109179"></a>5.1 REQUIREMENTS:
- Visual studio
- .net SDK version 6.0.0
- IdP will be Okta in this project
- SP service provider, RSK component is used in this project to be the SAML SP


## <a name="_toc153109180"></a>5.2 IMPLEMENTATION
### <a name="_toc153109181"></a>5.2.1 Create ASP.NET Core Web App
Select the .NET 6.0 option, and make sure “configure for HTTPS” box is checked 

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 016](https://github.com/Hasannemer/SAML-implementation/assets/95302818/b34de786-b428-494e-adbc-cdc23f1498ff)


<a name="_toc153109222"></a>
### <a name="_toc153109182"></a>5.2.2 Configure a view to display user claims
Add this code to the Home controller

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 017](https://github.com/Hasannemer/SAML-implementation/assets/95302818/0a90b229-694c-4325-b9bd-56a6a4618608)

Create a page named Details.cshtml in the Views folder in the Home section 

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 018](https://github.com/Hasannemer/SAML-implementation/assets/95302818/09dc0086-dec4-4c54-b6bf-97d41abff2a0)


Configure this page to display user claims

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 019](https://github.com/Hasannemer/SAML-implementation/assets/95302818/a1919912-6226-4da8-aacc-0d98f3db3bdf)

<a name="_toc153109223"></a>

Add it to the default \_layout.cshtml page 

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 020](https://github.com/Hasannemer/SAML-implementation/assets/95302818/86403c0a-ddf9-4c05-8d85-2bc3c0c53738)









### <a name="_toc153109183"></a>5.2.3 Install the RSK library 
Navigate for the NuGet package manager

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 021](https://github.com/Hasannemer/SAML-implementation/assets/95302818/40bd1ec7-d3a8-421e-adba-1fbc729cb59f)


Search for Rsk.Saml.IdentityServer4 package

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 022](https://github.com/Hasannemer/SAML-implementation/assets/95302818/ef311a6f-404c-4d63-9388-f52859ce4c93)


<a name="_toc153109224"></a>
### <a name="_toc153109184"></a>5.2.4 Initial configuration
Ask the IdentityServer.com for the license key, register, an email will be sent as follows:

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 023](https://github.com/Hasannemer/SAML-implementation/assets/95302818/3a5fe954-0112-475e-84a4-539daf5954c0)

Configure the Program.cs page 

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 024](https://github.com/Hasannemer/SAML-implementation/assets/95302818/83d3255d-dc47-4f81-a935-5bc66e8d59e9)


<a name="_ref153095647"></a><a name="_toc153109225"></a>

### <a name="_toc153109185"></a>5.2.5 IdP configuration
Sign in to Okta and create a new application 

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 025](https://github.com/Hasannemer/SAML-implementation/assets/95302818/b3cf8f45-6f31-4fae-8e37-d301908717dd)



Create a SAML2.0 application

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 026](https://github.com/Hasannemer/SAML-implementation/assets/95302818/de1aa4cb-9f59-408a-964e-6062b8cd1769)


<a name="_toc153109226"></a>

Configure the sign-on URL as the callback path we set [above](#mergeformat) ,then click NEXT

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 027](https://github.com/Hasannemer/SAML-implementation/assets/95302818/f4f00965-9152-4d3f-b102-117f0fcaee77)


Select I’m an Okta customer and click FINISH

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 028](https://github.com/Hasannemer/SAML-implementation/assets/95302818/b4f7f3fd-4eb2-4b0b-a92c-9698646ac54b)

Navigate for the “Sign on” section , you can find the metadata URL 

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 029](https://github.com/Hasannemer/SAML-implementation/assets/95302818/b4912062-ae88-40d0-bd54-3276d3478213)


<a name="_toc153109227"></a>








### <a name="_toc153109186"></a>5.2.6 Final Configuration 
Configure the Program file with the metadata URL 

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 030](https://github.com/Hasannemer/SAML-implementation/assets/95302818/7af6d7d0-708a-48df-873b-7a42431fe325)

### <a name="_toc153109187"></a>5.2.7 Assign Users
![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 031](https://github.com/Hasannemer/SAML-implementation/assets/95302818/bdcf25d7-6ac6-4041-b33d-d73824c83ed1)




## <a name="_toc153109188"></a>5.3 DEMO
![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 032](https://github.com/Hasannemer/SAML-implementation/assets/95302818/40bf7e8d-322b-49e6-abea-f9f2e7163061)


<a name="_toc153109228"></a>











The user is directed to IdP to be authenticated 

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 033](https://github.com/Hasannemer/SAML-implementation/assets/95302818/b764da2a-6ca5-4216-8d6b-51db91c7bcb9)



After user is verified, he is directed to the application 

User claims are displayed; user is authenticated using SAML integration

![Aspose Words aa363f05-473d-4a76-b78f-44ccbc5ae27c 034](https://github.com/Hasannemer/SAML-implementation/assets/95302818/3b1ffbd1-3027-4aa0-b4be-4c5542ccf9b1)





# <a name="_toc153109189"></a>6.Conclusion
## <a name="_toc153109190"></a>TO SUM UP
- went deep in the SAML standard 
- understand its components and its workflow 
- know where and when to use it 
- introduced SAML security risks
- simple implementation 
## <a name="_toc153109191"></a>FINAL WORDS
The SAML security standard significantly enhances enterprise efficiency by centralizing security and authentication responsibilities under the Identity Provider (IdP). However, for a manager overseeing software services, trust in the chosen IdP is crucial. Ensuring the reliability and security measures of the contracted IdP becomes a critical task. Evaluating the IdP's security protocols, level of trustworthiness, and storage limitations is essential. By making informed decisions about IdP partnerships, managers can confidently fortify their systems and user data, ensuring robust security measures align with their operational needs.


# <a name="_toc153109192"></a>7. References
**This article is written using the following resources:**

<a name="_ref153041828"></a><a name="_ref153041887"></a>https://www.onelogin.com/learn/saml

https://youtu.be/SvppXbpv-5k?si=Er0zAH3atNWdF2y-   

https://www.secureauth.com/blog/an-introduction-to-saml-security-assertion-markup-language/#:~:text=The%20standard%20specifies%20four%20main,support%20a%20defined%20use%20case.  

https://docs.oracle.com/cd/E19854-01/819-5209/gbpkr/index.html

https://research.nccgroup.com/2021/03/29/saml-xml-injection/   
