import { User } from "../models/User";
import { IUserState } from "./IUserState";

export const initialUserState: IUserState = {
    user: {} as User,
    users: [],
    fetchingData: false
}