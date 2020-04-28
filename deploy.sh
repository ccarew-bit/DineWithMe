docker build -t DineWithMe-image .

docker tag DineWithMe-image registry.heroku.com/corinnedinewithme/web


docker push registry.heroku.com/corinnedinewithme/web
