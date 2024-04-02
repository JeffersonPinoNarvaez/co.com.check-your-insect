import { h, resolveComponent } from 'vue'
import { createRouter, createWebHashHistory } from 'vue-router'

import DefaultLayout from '@/layouts/DefaultLayout'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: DefaultLayout,
    redirect: '/insect-search-v1',
    children: [
      {
        path: '/insect-search-v1',
        name: 'Insect Search 1.0',
        component: () => import('@/views/tools/insect-searching/InsectSearch.vue'),
      },
      {
        path: '/insects-101',
        name: 'Insects 101',
        component: () => import('@/views/education/Insects101.vue'),
      },
      {
        path: '/categories',
        name: 'Categories',
        component: () => import('@/views/education/Categories.vue'),
      },
      {
        path: '/terms-and-conditions',
        name: 'Terms and conditions',
        component: () => import('@/views/settings/TermsAndConditions.vue'),
      },
      {
        path: '/our-team',
        name: 'Our Team',
        component: () => import('@/views/settings/OurTeam.vue'),
      },
      {
        path: '/support',
        name: 'Support',
        component: () => import('@/views/settings/Support.vue'),
      },
    ],
  },
  // {
  //   path: '/pages',
  //   redirect: '/pages/404',
  //   name: 'Pages',
  //   component: {
  //     render() {
  //       return h(resolveComponent('router-view'))
  //     },
  //   },
  //   children: [
  //     {
  //       path: '404',
  //       name: 'Page404',
  //       component: () => import('@/views/pages/Page404'),
  //     },
  //     {
  //       path: '500',
  //       name: 'Page500',
  //       component: () => import('@/views/pages/Page500'),
  //     },
  //     {
  //       path: 'login',
  //       name: 'Login',
  //       component: () => import('@/views/pages/Login'),
  //     },
  //     {
  //       path: 'register',
  //       name: 'Register',
  //       component: () => import('@/views/pages/Register'),
  //     },
  //   ],
  // },
]

const router = createRouter({
  history: createWebHashHistory(process.env.BASE_URL),
  routes,
  scrollBehavior() {
    // always scroll to top
    return { top: 0 }
  },
})

export default router
