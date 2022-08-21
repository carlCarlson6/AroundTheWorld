import { CreateRecordRequestModel } from "./models/CreateRecordRequestModel";
import { Record } from "./models/Record";
import { Dispatch } from "react";
import { RecordAction } from "./models/action/RecordAction";
import Axios, { AxiosInstance } from "axios";

// TODO
export class RecordService {
    private httpClient: AxiosInstance = Axios.create({baseURL: process.env.REACT_APP_BACKEND_URL});
    constructor(private dispatch: Dispatch<RecordAction>) { }
    
    Create(record: CreateRecordRequestModel): string {
        throw new Error("not implemented");
    }

    GetAll(): Array<Record> {
        throw new Error("not implemented");
    }

    Get(recordId: string): Record {
        throw new Error("not implemented");
    }

    GetSum(): number {
        throw new Error("not implemented");
    }

}
