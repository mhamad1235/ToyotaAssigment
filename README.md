# ShareableURLs

## Overview

This AspNetCore App contains a few endpoints for (Brands, Categories, and Products) that require authentication.  
   
Authenticated users should have the capability to share specific items via URLs (links). These shared URLs must not require authentication, but they should have a limited lifespan, expiring within a specified duration (15 minutes).   

The current implementation of the following endpoints for generating Shareable URLs is incomplete:

- api/brands/{id}/get-shareable-url
- api/categories/{id}/get-shareable-url
- api/products/{id}/get-shareable-url


Your assignment is to implement these endpoints, considering the following aspects:
- Adhering to best security practices
- Following optimal programming practices
- Ensuring high performance

## Running The Application
Swagger UI is opened by default when running the application.  

![image](https://github.com/Toyota-Iraq/Assignment-ShareableURLs/assets/35940104/01856d82-6ea2-4fa3-91ef-dc1abe567db7)

<hr/>

You can call the `/login` endpoint with any random username & password.

![image](https://github.com/Toyota-Iraq/Assignment-ShareableURLs/assets/35940104/31da151b-f5d1-4047-8866-b9a52ae36a08)


<hr/>

Then you can use the Access Token inside the Swagger UI to call the rest protected endpoints.

![image](https://github.com/Toyota-Iraq/Assignment-ShareableURLs/assets/35940104/e8bcca79-2736-4e1a-84a7-e174ce1b70e2)


## Implementing the Incomplete feature
As mentioned above, all the 3 controllers contain endpoints for the required featre. But they're not implemented

![image](https://github.com/Toyota-Iraq/Assignment-ShareableURLs/assets/35940104/d074a835-7e2b-4cc2-a8b2-4f5949dfc2ca)
