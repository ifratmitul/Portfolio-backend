import { combineReducers } from 'redux'
import * as types from './types'
import agent from '../api/agent';

const Education = (type:string) => {

switch (type) {
     case types.GET_EDUCATION:
          return agent.Education.list();
          break;

     default:
          break;
}

}