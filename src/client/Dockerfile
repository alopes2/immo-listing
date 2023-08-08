#BUILD PHASE
FROM node:alpine as builder

WORKDIR /app

COPY package*.json ./
RUN npm install
COPY . .

RUN npm run build

#SERVE PHASE
FROM nginx
EXPOSE 80
COPY --from=builder /app/dist /usr/share/nginx/html

#The default command for nginx image is to start nginx