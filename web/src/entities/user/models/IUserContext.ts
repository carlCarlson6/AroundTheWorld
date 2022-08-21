import { IUserState } from "../state/IUserState";
import { UserService } from "../UserService";

export interface IUserContext {
    state: IUserState;
    service: UserService;
}