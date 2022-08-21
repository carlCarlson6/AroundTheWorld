import { User } from "../models/User";

export interface IUserState {
    users: Array<User>;
    user: User;
    fetchingData: boolean;
}