#Deriving the latest base image
FROM python:latest

LABEL Maintainer="navintc"

WORKDIR /usr/app/src

COPY sineGenerator.py ./

EXPOSE 5005

CMD [ "python", "./sineGenerator.py"]