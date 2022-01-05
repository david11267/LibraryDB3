using LibraryDB3.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<LibraryDB3Context>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();



//scaffholding command that builds libraryDBContext and all required models from the sql database callaed LibraryDB
//Scaffold-DbContext "Server=.\;Database=LibraryDB3;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model -f


// STEP1: Design database
// Step 2: Start .net webb project
// Step 3 install EF core, Ef tools and EF SQL server
// Step 4 paste scaffhold command in package manager console
// Step 5 insert dbcontext<> dependency injection
// step 6 Create Folder to then make razor pages for each