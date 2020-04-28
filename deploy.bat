docker build -t dinewithme-image .

docker tag dinewithme-image registry.heroku.com/corinnedinewithme/web


docker push registry.heroku.com/corinnedinewithme/web

heroku container:release web -a corinnedinewithme