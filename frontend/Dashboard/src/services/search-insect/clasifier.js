import api from "../api";

// Example function to login
export const classifierImage = async (image) => {
    try {
        const formData = new FormData();
        formData.append('file', image);
        const response = await api.post('images/PostImage', formData);
        return response;
      } catch (error) {
        throw new Error(error);
      }
  };