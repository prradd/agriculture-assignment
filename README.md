# Todo-list App - Asp.Net Core and Angular

This is a simple Todo-list app built with Asp.Net Core and Angular. The app allows users to create, read, update and delete tasks. The app is built with Asp.Net Core 3.1 and Angular 18.

## Requirements
- [.Net Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [Node.js 20](https://nodejs.org/en/)
- [Angular CLI 18](https://cli.angular.io/)
- [Visual Studio 2019](https://visualstudio.microsoft.com/)

## Deployment
```bash
# Clone the repository
git clone https://github.com/prradd/agriculture-assignment.git
```
### API
You may run it using Visual Studio 2019 or the command line.
```bash
cd agriculture-assignment/Assignments.API
dotnet restore
```

Update the connection string in the `appsettings.json` file.
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TodoList;User Id=sa;Password=your_password;"
    }
}
```

Run the migrations
```bash
dotnet ef database update
```

Run the API
```bash
dotnet run
```

### Client
```bash
cd agriculture-assignment/Assignments.Client
npm install
ng serve
# or
npm start
```

Open your browser and navigate to `http://localhost:4200/`

