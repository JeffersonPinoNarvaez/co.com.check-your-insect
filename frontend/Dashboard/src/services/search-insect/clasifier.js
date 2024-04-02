import api from "../api";

// Example function to login
export const classifierImage = async (image) => {
    try {
        const formData = new FormData();
        formData.append('file', image);
        const response = await api.post('images/PostImage', formData, {
            headers: {
              'Content-Type': 'multipart/form-data', // Set the Content-Type to multipart/form-data for FormData
            },
          });
        console.log(response)
        return response;
      } catch (error) {
        throw new Error(error);
      }
  };