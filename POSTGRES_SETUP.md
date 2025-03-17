# PostgreSQL Integration Guide

This guide explains how to integrate PostgreSQL with the BookStore Microservice application and connect it to the API.

## 📋 Prerequisites

- PostgreSQL installed locally or running in Docker
- pgAdmin (optional, for database management)
- .NET Core 5.0 SDK
- Entity Framework Core tools

## 🚀 Setup Steps

### 1. PostgreSQL Installation

#### Option A: Using Docker
```bash
# Pull PostgreSQL image
docker pull postgres:13

# Run PostgreSQL container
docker run --name bookstore-postgres -e POSTGRES_PASSWORD=your_password -e POSTGRES_DB=bookstore -p 5432:5432 -d postgres:13
```

#### Option B: Local Installation
1. Download PostgreSQL from [official website](https://www.postgresql.org/download/)
2. Install with default settings
3. Note down the password you set during installation

### 2. Database Connection String

Update the connection string in `appsettings.json` of each service:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=bookstore;Username=postgres;Password=your_password"
  }
}
```

### 3. Entity Framework Setup

1. **Install Required NuGet Packages**
```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

2. **Update DbContext**
```csharp
public class BookStoreContext : DbContext
{
    public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=bookstore;Username=postgres;Password=your_password");
        }
    }
}
```

### 4. Database Migrations

```bash
# Create initial migration
dotnet ef migrations add InitialCreate

# Apply migration to database
dotnet ef database update
```

### 5. API Configuration

1. **Update API Settings**
```json
{
  "ApiSettings": {
    "BaseUrl": "http://localhost:5002",
    "Timeout": 30,
    "RetryCount": 3
  }
}
```

2. **Configure CORS in API**
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseCors("AllowAll");
}
```

## 🔍 Testing the Connection

### 1. Database Connection Test

```csharp
public async Task<bool> TestConnection()
{
    try
    {
        await _context.Database.OpenConnectionAsync();
        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Database connection failed: {ex.Message}");
        return false;
    }
}
```

### 2. API Connection Test

```csharp
public async Task<bool> TestApiConnection()
{
    try
    {
        using var client = new HttpClient();
        var response = await client.GetAsync("http://localhost:5002/api/health");
        return response.IsSuccessStatusCode;
    }
    catch (Exception ex)
    {
        _logger.LogError($"API connection failed: {ex.Message}");
        return false;
    }
}
```

## 🐛 Troubleshooting

### Common Database Issues

1. **Connection Refused**
   - Check if PostgreSQL is running
   - Verify port (default: 5432)
   - Check firewall settings

2. **Authentication Failed**
   - Verify username and password
   - Check pg_hba.conf configuration
   - Ensure proper user permissions

3. **Database Not Found**
   - Create database if it doesn't exist
   - Check database name in connection string
   - Verify user has access to database

### Common API Issues

1. **CORS Errors**
   - Check CORS configuration
   - Verify allowed origins
   - Check request headers

2. **Connection Timeout**
   - Check API service is running
   - Verify network connectivity
   - Check firewall settings

3. **Authentication Issues**
   - Verify API keys/tokens
   - Check authentication headers
   - Validate user permissions

## 🔒 Security Best Practices

1. **Database Security**
   - Use strong passwords
   - Limit database access
   - Regular backups
   - Update PostgreSQL regularly

2. **API Security**
   - Use HTTPS
   - Implement rate limiting
   - Validate all inputs
   - Use proper authentication

## 📝 Monitoring

### Database Monitoring
```sql
-- Check active connections
SELECT * FROM pg_stat_activity;

-- Check database size
SELECT pg_size_pretty(pg_database_size('bookstore'));

-- Check table sizes
SELECT relname, pg_size_pretty(pg_relation_size(relid))
FROM pg_catalog.pg_statio_user_tables
ORDER BY pg_relation_size(relid) DESC;
```

### API Monitoring
- Use application insights
- Monitor response times
- Track error rates
- Set up alerts

## 🔄 Maintenance

### Regular Tasks
1. Database backups
2. Index maintenance
3. Performance monitoring
4. Security updates
5. Log rotation

### Backup Commands
```bash
# Backup database
pg_dump -U postgres bookstore > backup.sql

# Restore database
psql -U postgres bookstore < backup.sql
```

## 📚 Additional Resources

- [PostgreSQL Documentation](https://www.postgresql.org/docs/)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [Npgsql Documentation](https://www.npgsql.org/doc/)
- [Docker PostgreSQL Guide](https://hub.docker.com/_/postgres) 