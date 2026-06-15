# Build, Rebuild, Publish, and Deploy Guide

## 📚 Understanding the Concepts

### **1. BUILD**
- **What:** Compiles the code and checks for errors
- **Creates:** Debug files in `/bin/Debug/`
- **Takes:** ~5-10 seconds
- **When to use:** During development to check for errors

**Command:**
```bash
dotnet build
```

---

### **2. REBUILD**
- **What:** Cleans old compiled files and builds from scratch
- **Creates:** Fresh `/bin/` and `/obj/` directories
- **Takes:** ~10-15 seconds
- **When to use:** When you want a clean slate, after major changes

**Command:**
```bash
dotnet clean && dotnet build
```

**Or in Visual Studio:**
- Right-click Solution → **Rebuild Solution**

---

### **3. PUBLISH**
- **What:** Creates deployment-ready output
- **Creates:** Release files in `/bin/Release/` (optimized)
- **Includes:** All dependencies and runtime files
- **Output:** Can run on any machine with .NET installed
- **When to use:** Before deploying to production

**Command:**
```bash
dotnet publish -c Release -o ./publish
```

**Parameters:**
- `-c Release` → Optimized for production
- `-o ./publish` → Output folder

---

### **4. DEPLOY**
- **What:** Places the published files on target server
- **Destinations:** IIS, Azure, AWS, Docker, Linux, etc.
- **Preparation:** Publish first, then deploy
- **When to use:** Final step to make app live

**Methods:**
- Manual copy to server
- Docker deployment
- Azure App Service
- AWS EC2/Elastic Beanstalk
- GitHub Actions
- CI/CD Pipeline

---

## 🚀 Step-by-Step: Build → Publish → Deploy

### **Step 1: Build (Development)**

```bash
cd e:\dontnet-project\WebApplication1
dotnet build
```

**Output:** ✅ Build succeeded

---

### **Step 2: Rebuild (Clean Start)**

```bash
dotnet clean
dotnet build
```

**Or:**
```bash
dotnet clean && dotnet build
```

**Output:** ✅ All old files removed and rebuilt

---

### **Step 3: Publish (Production Ready)**

```bash
dotnet publish -c Release -o ./publish
```

**What gets created:**
```
publish/
├── WebApplication1                    (Executable)
├── WebApplication1.exe
├── WebApplication1.dll
├── appsettings.json
├── appsettings.Production.json
├── runtimes/                          (All dependencies)
├── refs/
└── ... (all necessary files)
```

**Verify:**
```bash
dir ./publish
```

---

### **Step 4: Test the Published Version**

```bash
cd ./publish
.\WebApplication1.exe
```

Or:
```bash
dotnet WebApplication1.dll
```

**Should see:**
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5129
```

---

## 🐳 Option 1: Docker Deployment

### **Create Dockerfile**

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY ./publish .

EXPOSE 5129

CMD ["dotnet", "WebApplication1.dll"]
```

### **Build Docker Image**

```bash
docker build -t student-api:1.0 .
```

### **Run Docker Container**

```bash
docker run -p 5129:5129 student-api:1.0
```

---

## ☁️ Option 2: Azure App Service Deployment

### **Prerequisites:**
- Azure account
- Azure CLI installed

### **Commands:**

```bash
# Login to Azure
az login

# Create resource group
az group create --name student-api-rg --location eastus

# Create App Service plan
az appservice plan create --name student-api-plan \
  --resource-group student-api-rg --sku B1 --is-linux

# Create Web App
az webapp create --resource-group student-api-rg \
  --plan student-api-plan --name student-api-app \
  --runtime "DOTNET|10.0"

# Publish and deploy
dotnet publish -c Release -o ./publish
cd publish
az webapp up --resource-group student-api-rg \
  --name student-api-app
```

---

## 🚢 Option 3: Manual IIS Deployment (Windows)

### **Step 1: Publish**
```bash
dotnet publish -c Release -o ./publish
```

### **Step 2: Copy to IIS folder**
```bash
# Copy publish folder to IIS directory
xcopy ".\publish\*" "C:\inetpub\wwwroot\student-api" /E /Y
```

### **Step 3: Configure IIS**
- Open IIS Manager
- Create new website
- Point to the published folder
- Configure binding (http/https)
- Set Application Pool to .NET

---

## 🔄 Option 4: GitHub Actions CI/CD

### **Create `.github/workflows/deploy.yml`**

```yaml
name: Build and Deploy

on:
  push:
    branches: [ main ]

jobs:
  build:
    runs-on: ubuntu-latest
    
    steps:
    - uses: actions/checkout@v2
    
    - name: Setup .NET
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: 10.0.x
    
    - name: Build
      run: dotnet build
    
    - name: Publish
      run: dotnet publish -c Release -o ${{env.DOTNET_ROOT}}/publish
    
    - name: Deploy to Azure
      run: |
        az webapp up --resource-group student-api-rg \
          --name student-api-app
```

---

## 📋 Complete Deployment Checklist

- [ ] Run `dotnet clean`
- [ ] Run `dotnet build` - verify no errors
- [ ] Run `dotnet test` - if tests exist
- [ ] Update `appsettings.Production.json`
- [ ] Run `dotnet publish -c Release -o ./publish`
- [ ] Test published version locally
- [ ] Choose deployment method (Docker/Azure/IIS/etc)
- [ ] Deploy to target environment
- [ ] Test endpoints in production
- [ ] Monitor health checks
- [ ] Setup logging and monitoring

---

## 🔐 Production Configuration Checklist

### **appsettings.Production.json**
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Production connection string here"
  }
}
```

### **Program.cs Configuration**
```csharp
if (!app.Environment.IsDevelopment())
{
    // Disable Swagger in production
    // Enable HTTPS only
    // Enable exception handling
}
```

---

## 🎯 Quick Command Reference

| Task | Command |
|------|---------|
| **Build** | `dotnet build` |
| **Rebuild** | `dotnet clean && dotnet build` |
| **Publish** | `dotnet publish -c Release -o ./publish` |
| **Run Locally** | `dotnet run` |
| **Run Published** | `dotnet ./publish/WebApplication1.dll` |
| **Docker Build** | `docker build -t student-api:1.0 .` |
| **Docker Run** | `docker run -p 5129:5129 student-api:1.0` |

---

## 📊 Deployment Flow Diagram

```
Source Code (Program.cs, Models, Controllers, etc)
    ↓
BUILD (dotnet build)
    ↓ (Check for errors)
    ↓
PUBLISH (dotnet publish -c Release)
    ↓ (Create deployable output)
    ↓
DEPLOY (Copy to server)
    ↓ (IIS/Azure/Docker/etc)
    ↓
LIVE API (Running on production)
    ↓ (http://yourdomain.com/api/...)
```

---

## ✅ Verification Checklist

After deployment, verify:

```bash
# Check if API is running
curl http://your-api-url/api/health

# Expected response:
{
  "status": "Healthy",
  "service": "Student Management API",
  "version": "1.0.0"
}

# Check Swagger documentation
curl http://your-api-url/swagger

# Test a student endpoint
curl http://your-api-url/api/students
```

---

## 🚀 Your Next Steps

1. **Choose a deployment method:**
   - Docker (simplest)
   - Azure (cloud)
   - IIS (Windows server)
   - GitHub Actions (automated)

2. **Prepare deployment files**
3. **Test published version locally**
4. **Deploy to target environment**
5. **Monitor and maintain**

---

**Date:** June 15, 2026  
**API:** Student Management API v1.0.0  
**Status:** Ready for Deployment ✅

