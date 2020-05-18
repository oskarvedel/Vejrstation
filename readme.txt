Set up user secrets:

1) Navigate to the project folder and run the following three commands. These will set up the user secrets that are read by the ASP startup process.  

dotnet user-secrets init

dotnet user-secrets set "AppSettings:JwtSecret" "TTRrSvak5s1xra9fM6Rk"

dotnet user-secrets set "AppSettings:BCryptWorkFactor" "10"




Set up database:

There are two options for connecting to the sql server.

1) The first option is to keep the code as it is, and create an environment variable on your PC. The environment variable needs to be named whatever name is specified as the param of GetEnvironmentVariable(). In this case "WeatherServerDb"

var connString = System.Environment.GetEnvironmentVariable("WeatherServerDb");
            
services.AddDbContext<WeatherServerDbContext>(options =>
                options.UseSqlServer(connString));


2) The quicker solution is to just change the parameter of the UseSqlServer() call to match your system. 


Afterwards run the command:

dotnet ef database update

