# image4ioDotNetSDK
image4io is a cloud service where your images are uploaded, moved, copied, feched, deleted.

<h2>Configuration</h2>
<p>
 API key and APIsecret must be defined in order to send requests to API.
</p>

<h2>Usage</h2>
<p>With Image4io it is very easy to do an operation on your images. <br><br>
The following example uploads a file from your local to cloud. The Path parameter is optional</p>

```
FileStream stream = File.Open(@"Assets\a.png", FileMode.Open);

 var model = new image4ioDotNetSDK.Models.UploadRequestModel()
            {
                Path = "filepath"
            };
            
            model.Files.Add(stream);  
            var response = api.Upload(model);
            
```


<p>The following example deletes a file from your cloud.</p>


```
  var model = new image4ioDotNetSDK.Models.DeleteRequestModel
  
            {
                name = "image.jpg"
            };

            var response = api.Delete(model);
```
Running Unit Tests
* Clone the repository to your local: > git clone https://github.com/Image4IO/image4ioDotNetSDK.git
* Open image4ioDotNetSDK.sln > image4ioDotNetSDKTest
* UnitTest1 > Run Tests



<h2>Contact Us</h2>

Image4io team is always ready to support you.

https://image4.io/en/contact

<h2>Follow Us</h2>

Blog: https://image4.io/en/blog/ <br>
Twitter: https://twitter.com/image4io <br>
LinkedIn : https://www.linkedin.com/company/image4io/


