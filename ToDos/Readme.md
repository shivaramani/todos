# make sure to provide a NEW repository name
- aws codecommit create-repository --repository-name todos --repository-description "todos c# with api, lambda and dynamodb repository" 

# make sure to provide a new bucket name
- create bucket todo-dev-deploy1
    - aws s3 mb s3://todo-dev-deploy1
- Build and Publish the project
    - dotnet restore ToDos.csproj
    - dotnet publish -c release -o ./build_output ToDos.csproj

# make sure you have aws cli, SAM cli installed
# make sure to provide the above S3 Bucket name
- SAM package and Deploy
    - sam package --template-file template.yaml --output-template todos.yaml --s3-bucket todo-dev-deploy1 --metadata ToDoTableName=todos
    - sam deploy  --template-file todos.yaml --stack-name ToDos --capabilities CAPABILITY_IAM --region us-east-1 --parameter-overrides Env=dev ShouldCreateTable=true ToDoTableName=todos
    
    
Example:

  {
    "Id": "1",
    "Task": "First ToDo",
    "TaskDescription": "First ToDo Description",
    "User": "Shiva",
    "IsDone": true,
    "CreatedTimestamp": "2019-04-15T01:56:16.13+00:00"
  }

