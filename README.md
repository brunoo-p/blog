# Blog
<h3> Este projeto rodando em microserviços simula a api de um blog. </h3>
<p>
  <img alt="C#" src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white"/>
  <img alt="MongoDB" src ="https://img.shields.io/badge/MongoDB-%234ea94b.svg?style=for-the-badge&logo=mongodb&logoColor=white"/>
  <img alt="xUnit" src="https://img.shields.io/badge/_-xUnit-Withe?style=for-the-badge" />
</p>
<br/>

# Pré-Requisito
<h4>Tenha o Docker: https://www.docker.com/products/docker-desktop</h4>

<br/>

# Começando 🚀
<h4>Primeiro será necessário clonar o repositório</h4>
  <h5>Abra o prompt e digite</h5>
  
```shel
mkdir Blog
cd Blog
```

```shel
git clone https://github.com/brunoo-p/blog.git
```

## Construindo e iniciando 🔧⚙
```shel
cd Blog [root folder] 
docker-compose up -d
```
<strong> obs: Se for iniciar fora do docker, opte pela url em 'https' <strong>

<br />

## Finalizar containers 🔧⚙
```shel
docker-compose down
```
<br/>

- O comando ``` docker-compose up -d ``` irá iniciar em background 3 containers, sendo:

  - MONGO: Microserviço do Mongo Database rodando em ``localhost: 27017``
      - ``portas: 27017:27017``
      
  - MONGO-EXPRESS: Monitoramento do container "mongo" trazendo uma interface dos documents e collections ```localhost:8081```
      - ``portas: 8081:8081``
      - Browser irá pedir senha -  ``usuário: kali | senha: kali``
      
  - API: WebApi em AspNetCore version=6.0  HTTP ``localhost: 5000``
      - ``portas: 5000:5000``
      
 - Também criará um diretório "DATA" para persistência de dados mesmo com a finalização do container.
 
 
<br/>
  


# Testes 🚦🎓

## Backend
### Testes enxutos mostrando a quantidade que passou ou reprovou
```shel
cd blog.tests
dotnet test
```

### Testes mais verbosos detalhando em texto a intenção
```shel
cd blog.tests
dotnet test -l "console;verbisity=detailed" 
```
