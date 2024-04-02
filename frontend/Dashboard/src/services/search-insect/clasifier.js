import api from "../api";

// Example function to login
export const classifierImage = async (data= FormData) => {
  try {
    return await api.post('images/PostImage', data, {
      headers: {
        'Content-Type': `multipart/form-data`,
      },
    });
  } catch (error) {
    throw new Error(error);
  }
};