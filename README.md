# BookStore Microservice Application

A modern microservices-based bookstore application built with .NET Core and Angular, featuring a distributed architecture with multiple services.

## 🚀 Features

- Microservices Architecture
- Angular Frontend
- .NET Core Backend Services
- SQL Server Database
- RabbitMQ Message Broker
- OAuth2 Authentication
- API Gateway
- Docker Support

## 🛠️ Tech Stack

- **Frontend**: Angular
- **Backend**: .NET Core 5.0
- **Database**: SQL Server
- **Message Broker**: RabbitMQ
- **Authentication**: Identity Server 4
- **API Gateway**: Ocelot
- **Containerization**: Docker
- **Orchestration**: Docker Compose

## 📋 Prerequisites

- Docker Desktop
- At least 4GB RAM
- At least 10GB free disk space
- Git

## 🚀 Getting Started

### Using Docker (Recommended)

1. **Clone the Repository**
   ```bash
   git clone [repository-url]
   cd BookStore-Microservice-Angular-master
   ```

2. **Start Docker Desktop**
   - Open Docker Desktop
   - Wait for it to be fully running

3. **Run the Application**
   ```bash
   docker-compose up --build
   ```

4. **Access the Application**
   - Frontend: http://localhost:4200
   - API Gateway: http://localhost:5000
   - OAuth Service: http://localhost:5001
   - Web API: http://localhost:5002
   - RabbitMQ Management: http://localhost:15672

### Manual Setup (Alternative)

1. **Database Setup**
   - Install SQL Server
   - Create database
   - Update connection strings in appsettings.json

2. **RabbitMQ Setup**
   - Install RabbitMQ
   - Configure credentials
   - Update connection settings

3. **Backend Services**
   ```bash
   # Build and run each service
   cd Endpoints.HttpGateway
   dotnet run
   
   cd ../Endpoints.Oauth
   dotnet run
   
   cd ../Endpoints.WebApi
   dotnet run
   ```

4. **Frontend Setup**
   ```bash
   cd book-seller
   npm install
   ng serve
   ```

## 🔑 Default Credentials

### Application Login
- **Username**: admin@live.com
- **Password**: admin@123

### Database
- **Server**: localhost,1433
- **Username**: sa
- **Password**: YourStrong@Passw0rd

### RabbitMQ
- **Username**: guest
- **Password**: guest

## 🏗️ Project Structure

```
BookStore-Microservice-Angular-master/
├── Endpoints.HttpGateway/     # API Gateway Service
├── Endpoints.Oauth/           # Authentication Service
├── Endpoints.WebApi/          # Main Web API Service
├── book-seller/              # Angular Frontend
├── docker-compose.yml        # Docker Compose Configuration
└── README.md                 # This File
```

## 🔧 Docker Commands

```bash
# Start all services
docker-compose up

# Start in detached mode
docker-compose up -d

# Stop all services
docker-compose down

# View logs
docker-compose logs -f

# Rebuild specific service
docker-compose up --build [service-name]

# Remove all containers and volumes
docker-compose down -v
```

## 🐛 Troubleshooting

### Common Issues

1. **Port Conflicts**
   - Check if ports 4200, 5000, 5001, 5002, 1433, 5672, or 15672 are in use
   - Modify port mappings in docker-compose.yml if needed

2. **Container Issues**
   - Check container logs: `docker-compose logs [service-name]`
   - Ensure Docker Desktop is running
   - Verify sufficient system resources

3. **Database Connection**
   - Verify SQL Server container is running
   - Check connection strings in appsettings.json

4. **RabbitMQ Issues**
   - Access RabbitMQ Management UI at http://localhost:15672
   - Verify credentials in configuration

## 🔒 Security Considerations

- Change default passwords in production
- Update connection strings
- Configure proper CORS policies
- Implement proper authentication flows
- Secure API endpoints

## 🧹 Cleanup

To completely remove the project:

```bash
# Stop and remove containers
docker-compose down

# Remove volumes
docker-compose down -v

# Remove images
docker rmi $(docker images -q)
```

## 📝 Development Guidelines

1. **Code Style**
   - Follow C# coding conventions
   - Use Angular style guide
   - Maintain consistent formatting

2. **Git Workflow**
   - Create feature branches
   - Write meaningful commit messages
   - Follow pull request guidelines

3. **Testing**
   - Write unit tests
   - Perform integration testing
   - Test microservices independently

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 👥 Support

For support, please:
1. Check the documentation
2. Review existing issues
3. Create a new issue if needed

## 🙏 Acknowledgments

- .NET Core Team
- Angular Team
- Docker Team
- All contributors to this project
