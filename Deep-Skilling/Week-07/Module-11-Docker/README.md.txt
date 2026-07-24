# 🐳 Module 11 - Docker

## 📌 Objective

The objective of this module is to understand Docker, containerization, Docker architecture, Docker images, containers, Docker Hub, Dockerfile, and commonly used Docker commands. Docker helps developers package applications and their dependencies into lightweight containers, ensuring consistency across different environments.

---

# 📖 What is Docker?

Docker is an open-source containerization platform that enables developers to build, package, and run applications in isolated environments called **containers**.

Containers include everything required to run an application, including:

- Application Code
- Runtime
- System Libraries
- Dependencies
- Configuration Files

Docker ensures that applications run consistently across development, testing, and production environments.

---

# 📦 What is Containerization?

Containerization is the process of packaging an application and all its required dependencies into a single executable unit called a **container**.

### Benefits of Containerization

- Consistent execution across environments
- Lightweight compared to virtual machines
- Fast application startup
- Easy portability
- Better resource utilization

---

# ⚙️ Docker Architecture

Docker consists of the following major components:

### Docker Client

The Docker Client is the command-line interface (CLI) used to interact with Docker.

Example commands:

```bash
docker build
docker run
docker pull
docker push
```

### Docker Daemon

The Docker Daemon (`dockerd`) manages Docker objects such as:

- Images
- Containers
- Networks
- Volumes

It receives commands from the Docker Client and performs the requested operations.

### Docker Images

A Docker Image is a read-only template that contains everything needed to create a Docker Container.

It includes:

- Application code
- Runtime
- Libraries
- Dependencies
- Environment settings

### Docker Containers

A Docker Container is a running instance of a Docker Image.

Containers are:

- Lightweight
- Portable
- Isolated
- Fast
- Easy to deploy

### Docker Registry

A Docker Registry stores Docker Images.

The most commonly used registry is **Docker Hub**.

---

# ☁️ Docker Hub

Docker Hub is the official cloud repository for Docker Images.

It provides:

- Official Images
- Public Repositories
- Private Repositories
- Image Sharing
- Version Control

---

# 📄 Dockerfile

A Dockerfile is a text file containing instructions for building Docker Images.

Example:

```dockerfile
FROM ubuntu:22.04

WORKDIR /app

COPY . .

RUN apt-get update

CMD ["bash"]
```

---

# 🔄 Docker Workflow

A typical Docker workflow consists of:

1. Write Application Code
2. Create Dockerfile
3. Build Docker Image
4. Run Docker Container
5. Test the Application
6. Push Image to Docker Hub
7. Deploy Container

---

# 💻 Common Docker Commands

| Command | Description |
|----------|-------------|
| `docker --version` | Display Docker version |
| `docker pull nginx` | Download an image |
| `docker images` | List downloaded images |
| `docker run nginx` | Run a container |
| `docker ps` | Show running containers |
| `docker ps -a` | Show all containers |
| `docker stop <container_id>` | Stop a container |
| `docker rm <container_id>` | Remove a container |
| `docker rmi <image_name>` | Remove an image |

---

# 📊 Docker vs Virtual Machine

| Docker | Virtual Machine |
|---------|-----------------|
| Lightweight | Heavyweight |
| Shares Host OS | Requires Guest OS |
| Fast Startup | Slow Startup |
| Less Memory Usage | More Memory Usage |
| High Performance | Lower Performance |

---

# ✅ Advantages of Docker

- Lightweight
- Platform Independent
- Faster Deployment
- High Portability
- Better Resource Utilization
- Easy Scalability
- Simplified Application Deployment
- Improved Development Workflow

---

# 🚀 Applications of Docker

Docker is widely used in:

- Web Application Deployment
- Microservices Architecture
- Cloud Computing
- DevOps
- Continuous Integration (CI)
- Continuous Deployment (CD)
- Testing Environments

---

# 🛠 Tools Covered

- Docker Desktop
- Docker CLI
- Docker Hub

---

# 📚 Learning Outcomes

After completing this module, I learned:

- Docker Fundamentals
- Containerization Concepts
- Docker Architecture
- Docker Images and Containers
- Docker Hub
- Dockerfile
- Docker Workflow
- Docker Commands
- Advantages of Docker

---

# 📌 Module Status

- ✅ Self Learning Completed
- ✅ Docker Concepts Studied
- ✅ Basic Docker Commands Learned

---

# 🎯 Conclusion

Docker simplifies software development by packaging applications and their dependencies into portable containers. It enables consistent deployment across different environments, reduces dependency issues, improves scalability, and plays a key role in modern DevOps and cloud-native application development.