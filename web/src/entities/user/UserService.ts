import Axios, { AxiosInstance } from "axios";
import { Dispatch } from "react";
import { UserAction } from "./models/action/UserAction";
import { User } from "./models/User";

// TODO
export class UserService {
    private httpClient: AxiosInstance = Axios.create({baseURL: process.env.REACT_APP_BACKEND_URL});
    constructor(private dispatch: Dispatch<UserAction>) { }

    Create(): string {
        throw new Error("not implemented");
    }

    GetAll(): Array<User> {
        throw new Error("not implemented");
    }

    Get(userId: string): User {
        throw new Error("not implemented");
    }

    GetRecords(userId: string): number {
        throw new Error("not implemented");
    }

    GetRecordsSum(userId: string): number {
        throw new Error("not implemented");
    }

}