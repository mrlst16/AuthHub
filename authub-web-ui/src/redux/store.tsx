import '../redux/reducer'
import { configureStore } from '@reduxjs/toolkit'
import appReducer from '../redux/reducer'

const store = configureStore({
    reducer: appReducer
});

export default store;