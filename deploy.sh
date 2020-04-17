docker build -t DineWithMe-image .

docker tag DineWithMe-image registry.heroku.com/DineWithMe/web


docker push registry.heroku.com/DineWithMe/web

heroku container:release web -a DineWithMe