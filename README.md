# image4ioDotNetSDK

image4io is a cloud service where your images are uploaded, moved, copied, feched, deleted.

## Configuration

To send requests to API, APIKey.key and APISecret.key must be created first. Then, APIKey and APISecret should written into files.

 ```charp
  public TestsFixture()
        {
            string apiKey = File.ReadAllText("APIKey.key");
            string apiSecret = File.ReadAllText("APISecret.key");
            Api = new Image4ioAPI(apisecret,apikey);
        }
```

## Usage

With Image4io it is very easy to do an operation on your images.

The following example uploads a file from your local to cloud. The Path parameter is optional

```csharp
FileStream stream = File.Open(@"Assets\a.png", FileMode.Open);

 var model = new image4ioDotNetSDK.Models.UploadRequestModel()
            {
                Path = "filepath"
            };
            model.Files.Add(stream);  
            var response = api.Upload(model);
```

The following example deletes a file from your cloud.

```csharp
  var model = new image4ioDotNetSDK.Models.DeleteRequestModel
  
            {
                name = "image.jpg"
            };

            var response = api.Delete(model);
```

### Running Unit Tests

* Clone the repository to your local `:> git clone https://github.com/Image4IO/image4ioDotNetSDK.git`
* Open image4ioDotNetSDK.sln > image4ioDotNetSDKTest
* UnitTest1 > Run Tests

## Contact Us

Image4io team is always ready to support you.

[image4.io/en/contact](https://image4.io/en/contact)

## Follow Us

Blog: [image4.io/en/blog/](https://image4.io/en/blog/)

Twitter: [twitter.com/image4io](https://twitter.com/image4io)

LinkedIn : [linkedin.com/company/image4io/](https://www.linkedin.com/company/image4io/)
