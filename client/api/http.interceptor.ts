import axios, { AxiosError, AxiosResponse } from "axios";
axios.interceptors.response.use(
    async (response) => {
        return response;
    },
    (error: AxiosError) => {
        const { status } = error.response!;
        switch (status) {
            case 400:
                console.log(error.response);
                break;
            case 401:
                console.log("Unauthorized");
                break;
            case 404:
                console.log(error.response?.status);
                break;
            case 500:
                console.log("server error");
                break;
            default:
                console.log("an unknown error occurred");
                break;
        }
        return Promise.reject(error);
    }
);
