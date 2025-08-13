import { useForm, type SubmitHandler } from "react-hook-form";
import { Link } from "react-router";
import { toast, Toaster } from "sonner";

type InputLogin = {
  email: string;
  password: string;
  passwordConfirmation: string;
}

export default function Register() {

  const { handleSubmit, register } = useForm<InputLogin>();
  const onSubmit: SubmitHandler<InputLogin> = (data) => {
    if (data.password != data.passwordConfirmation) {
      toast.error("Password Confirmation and Password not same");
      return;
    }
    toast.error("theres error in here");
  }

  return <>
    <div className="flex h-screen justify-center items-center flex-col">
      <form onSubmit={handleSubmit(onSubmit)} className="w-sm gap-2 flex flex-col shrink-0 bg-gray-200 dark:bg-gray-800 p-8 rounded-2xl mb-2">

        <h1 className="text-2xl mb-2">Register</h1>
        <div>
          <label htmlFor="email">Email</label>
          <input {...register("email")} id="email" type="email" placeholder="hai@mail.com" className="w-full dark:bg-gray-900 dark:text-white rounded-xl" required />
        </div>

        <div>
          <label htmlFor="password">Password</label>
          <input {...register("password")} id="password" type="password" placeholder="password" className="w-full dark:bg-gray-900 dark:text-white rounded-xl" autoComplete="current-password" required />
        </div>

        <div>
          <label htmlFor="passwordConfirmation">Password Confirmation</label>
          <input {...register("passwordConfirmation")} id="passwordConfirmation" type="password" placeholder="password" className="w-full dark:bg-gray-900 dark:text-white rounded-xl" autoComplete="current-password" required />
        </div>

        <button className="mt-2 border p-2 text-white bg-blue-600 hover:opacity-60 rounded-xl border-none">Submit</button>
      </form>
      <Link to="/login" className="mt-2 text-sm text-center">Already Have an Account</Link>
    </div>
  </>;
}
