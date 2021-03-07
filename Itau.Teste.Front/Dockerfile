FROM node:12.18-alpine as node

WORKDIR /app

COPY Itau.Teste.Front/package.json /app
RUN npm install --silent
COPY ./Itau.Teste.Front/ .
RUN npm run build

FROM nginx:alpine
VOLUME /var/cache/nginx
COPY --from=node app/dist/itau-teste-front /usr/share/nginx/html
COPY ./Itau.Teste.Front/config/nginx.conf /etc/nginx/conf.d/default.conf
