import * as yup from 'yup'

export const loginValidationShema = yup.object({
    email: yup.string()
        .email("Incorrect email")
        .required("Enter email"),
    password: yup
        .string()
        .min(5, 'Password should be of minimum 5 characters length')
        .required('Password is required')
        // .matches(
        //     /^(?=.*[A-Za-z])(?=.*d)(?=.*[@$!%*#?&])[A-Za-zd@$!%*#?&]{8,}$/,
        //     "Must Contain 8 Characters, One Uppercase, One Lowercase, One Number and one special case Character"
        //   ),
})