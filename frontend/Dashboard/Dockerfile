# Builder stage for building the Node.js application
FROM node:alpine AS builder

WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .
RUN npm run build

# Final stage using Nginx to serve the built application
FROM nginx:alpine

# Remove the default nginx welcome page
RUN rm -rf /usr/share/nginx/html/*

# Copy the built files from the builder stage to Nginx's HTML directory
COPY --from=builder /app/dist /usr/share/nginx/html

# Expose port 80
EXPOSE 8080

# Start Nginx in the foreground to serve the application
CMD ["nginx", "-g", "daemon off;"]