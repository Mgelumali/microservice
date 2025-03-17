FROM node:14 AS build
WORKDIR /app
COPY book-seller/package*.json ./
RUN npm install
COPY book-seller/ .
RUN npm run build -- --prod

FROM nginx:alpine
COPY --from=build /app/dist/book-seller /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"] 