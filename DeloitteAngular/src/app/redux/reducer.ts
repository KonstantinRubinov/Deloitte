import { Store } from "./store";
import { Action } from "./action";
import { ActionType } from "./action-type";

export class Reducer{
    public static reduce(oldStore: Store, action:Action):Store{
        let newStore:Store = {...oldStore};

        switch(action.type){
            case ActionType.GetPersons:
                newStore.persons = action.payload;
                break;
            default:
                break;
        }

        return newStore;

    }
}