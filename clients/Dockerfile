# Build Stage
FROM node:latest AS build-env
WORKDIR /source
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build --  --prod -c production

### STAGE 2: Run ###
FROM nginx:latest
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build-env /source/dist/* /usr/share/nginx/html
