import axios from "axios";

const API_URL = "http://localhost:5225/api/Tasks"; // HTTP


export const createTask = async (title: string) => {
  try {
    const response = await axios.post(API_URL, { title });
    return response.data;
  } catch (error: any) {
    if (error.response) {
      // Erreurs de validation renvoyées par ton backend
      return { errors: error.response.data };
    }
    throw error;
  }
};
