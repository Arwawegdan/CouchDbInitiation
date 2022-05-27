WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);

// Add services to the container.

webApplicationBuilder.Services.AddControllersWithViews();
webApplicationBuilder.Services.AddRazorPages();

string endpoint = "cb.of1v1nxtjl70kq.cloud.couchbase.com";
string bucketName = "couchbasecloudbucket";
string username = "ArwaDatabase";
string password = "Arwa1352$";
// User Input ends here.

// Initialize the Connection
ClusterOptions opts = new ClusterOptions().WithCredentials(username, password);
// opts = opts.WithLogging(loggerFactory);
opts.IgnoreRemoteCertificateNameMismatch = true;

ICluster cluster = await Cluster.ConnectAsync("couchbases://" + endpoint, opts);
IBucket bucket = await cluster.BucketAsync(bucketName);
ICouchbaseCollection collection = bucket.DefaultCollection();

CouchDbRepository<Book> bookRepository = new CouchDbRepository<Book>(collection);
webApplicationBuilder.Services.AddSingleton(bookRepository);
WebApplication app = webApplicationBuilder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseWebAssemblyDebugging();
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();