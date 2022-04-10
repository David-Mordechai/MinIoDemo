using Minio;

var minIo = new MinioClient()
    .WithEndpoint(new Uri("localhost:9000"))
    .WithCredentials("access-key", "secret-key")
    .Build();

var listArgs = new ListObjectsArgs()
    .WithBucket("test");

minIo
    .ListObjectsAsync(listArgs)
    .Subscribe(
        item => { Console.WriteLine($"Object: {item.Key}"); },
        ex => { Console.WriteLine($"OnError: {ex}"); },
        () => { Console.WriteLine("Listed all objects in bucket 'test'"); }
    );
Console.ReadKey();