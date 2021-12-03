import * as AuthActionCreators from './auth';
import * as ProductActionCreators from './product';
import * as ProfileActionCreators from './profile';

export default {
    ...AuthActionCreators,
    ...ProductActionCreators,
    ...ProfileActionCreators
}