# Merch-api
Сервис учета выдачи мерча сотрудникам

# Схема сервисов -> http://c_route256.tilda.ws/workshop_1

# Команды докера:
- docker build -t merch-api . 
- docker run -d -p 5000:80 merch-api
- docker rename OLD_NAME merchandise_service
- docker build -t merchandise-service . 
- docker run -d -p 5000:80 merchandise-service
- docker rmi $(docker images -a -q)  -- удалить все образы
- docker login <server> -u <username> -p <password>
- docker-compose build
- docker-compose up
