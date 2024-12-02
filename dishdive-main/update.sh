#!/bin/bash

repo="slobodanstar/dishdive_backend"
tag="latest"

./gradlew shadowJar

docker build -t $repo:$tag .

docker login

docker push $repo:$tag