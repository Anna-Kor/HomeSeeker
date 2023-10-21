<script setup lang="ts">
    import { ref } from 'vue';
    import { useForm, useField } from 'vee-validate';
    import { storeToRefs } from 'pinia';
    import * as Yup from 'yup';
    import { QBtn, QCheckbox, QInput, QItem, QItemSection, QSelect } from 'quasar';

    import { Category, Floor, FloorsQuantity, HomeType, RoomsQuantity, type IAddHomeCommand, BathroomsQuantity } from '@/clients';
    import { useAnnouncementsStore, useAuthStore } from '@/stores';

    const authStore = useAuthStore();
    const { user } = storeToRefs(authStore);

    const cities = [
        'Warszawa', 'Lublin', 'Rzeszów', 'Gdynia', 'Wrocław'
    ]

    const schema = Yup.object().shape({
        category: Yup.mixed<Category>()
            .required('Category must be set')
            .oneOf(Object.values(Category)),
        type: Yup.mixed<HomeType>()
            .required('Home type must be set')
            .oneOf(Object.values(HomeType)),
        name: Yup.string()
            .required('Title must be set')
            .max(35, 'Title must be shorter than 35 signs'),
        price: Yup.number()
            .transform((value) => Number.isNaN(value) ? null : value)
            .required("Price is required"),
        rent: Yup.number()
            .when("type", {
                is: HomeType.ForRent,
                then: (schema) => schema.transform((value) => Number.isNaN(value) ? null : value).required("Rent is required")
            }),
        city: Yup.string()
            .required('City is required'),
        livingArea: Yup.number()
            .transform((value) => Number.isNaN(value) ? null : value)
            .required('Living area is required'),
        lotArea: Yup.number()
            .nullable()
            .transform((value) => Number.isNaN(value) ? null : value),
        floor: Yup.mixed<Floor>()
            .when("category", {
                is: Category.Flat,
                then: (schema) => schema.oneOf(Object.values(Floor)).required("Floor is required")
            }),
        floorsQuantity: Yup.mixed<FloorsQuantity>()
            .when("category", {
                is: Category.House,
                then: (schema) => schema.oneOf(Object.values(FloorsQuantity)).required("Floors quantity is required")
            }),
        hasFurniture: Yup.boolean(),
        roomsQuantity: Yup.mixed<RoomsQuantity>()
            .oneOf(Object.values(RoomsQuantity)),
        bathroomsQuantity: Yup.mixed<BathroomsQuantity>()
            .oneOf(Object.values(BathroomsQuantity)),
        description: Yup.string()
    });

    const { handleSubmit } = useForm({
        validationSchema: schema,
        initialValues:
        {
            hasFurniture: false
        }
    });

    const { value: category, errorMessage: categoryError } = useField<Category>('category');
    const filteredCategories = ref(Object.values(Category));

    const { value: type, errorMessage: typeError } = useField<HomeType>('type');
    const filteredTypes = ref(Object.values(HomeType));

    const { value: name, errorMessage: nameError } = useField<string>('name');
    const { value: price, errorMessage: priceError } = useField<number>('price');
    const { value: rent, errorMessage: rentError } = useField<number>('rent');

    const { value: city, errorMessage: cityError } = useField<string>('city');
    const filteredCities = ref(cities);

    const { value: livingArea, errorMessage: livingAreaError } = useField<number>('livingArea');
    const { value: lotArea, errorMessage: lotAreaError } = useField<number>('lotArea');

    const { value: floor, errorMessage: floorError } = useField<Floor>('floor');
    const filteredFloors = ref(Object.values(Floor));

    const { value: floorsQuantity, errorMessage: floorsQuantityError } = useField<FloorsQuantity>('floorsQuantity');
    const filteredFloorsQuantities = ref(Object.values(FloorsQuantity));

    const { value: hasFurniture } = useField<boolean>('hasFurniture');

    const { value: roomsQuantity, errorMessage: roomsQuantityError } = useField<FloorsQuantity>('roomsQuantity');
    const filteredRoomsQuantities = ref(Object.values(RoomsQuantity));

    const { value: bathroomsQuantity, errorMessage: bathroomsQuantityError } = useField<FloorsQuantity>('bathroomsQuantity');
    const filteredBathroomsQuantities = ref(Object.values(BathroomsQuantity));

    const { value: description, errorMessage: descriptionError } = useField<number>('description');

    const onSubmit = handleSubmit( async (values: any) => {
        try {
            values.createdUserId = user.value?.id as number;
            const announcementsStore = useAnnouncementsStore();
            await announcementsStore.addHome(values as IAddHomeCommand);
        } catch (error) {
            console.log(error);
        }
    });

    function categoriesFilterFn(val: string, update: any) {
        if (val === '') {
            update(() => {
                filteredCategories.value = Object.values(Category);
            })
            return
        }

        update(() => {
            const needle = val.toLowerCase()
            filteredCategories.value = Object.values(Category).filter(v => v.toLowerCase().indexOf(needle) > -1)
        })
    };

    function typesFilterFn(val: string, update: any) {
        if (val === '') {
            update(() => {
                filteredTypes.value = Object.values(HomeType);
            })
            return
        }

        update(() => {
            const needle = val.toLowerCase()
            filteredTypes.value = Object.values(HomeType).filter(v => v.toLowerCase().indexOf(needle) > -1)
        })
    };

    function citiesFilterFn(val: string, update: any) {
        if (val === '') {
            update(() => {
                filteredCities.value = cities;
            })
            return
        }

        update(() => {
            const needle = val.toLowerCase()
            filteredCities.value = cities.filter(v => v.toLowerCase().indexOf(needle) > -1)
        })
    };

    function floorsFilterFn(val: string, update: any) {
        if (val === '') {
            update(() => {
                filteredFloors.value = Object.values(Floor);
            })
            return
        }

        update(() => {
            const needle = val.toLowerCase()
            filteredFloors.value = Object.values(Floor).filter(v => v.toLowerCase().indexOf(needle) > -1)
        })
    };

    function floorsQuantitiesFilterFn(val: string, update: any) {
        if (val === '') {
            update(() => {
                filteredFloorsQuantities.value = Object.values(FloorsQuantity);
            })
            return
        }

        update(() => {
            const needle = val.toLowerCase()
            filteredFloorsQuantities.value = Object.values(FloorsQuantity).filter(v => v.toLowerCase().indexOf(needle) > -1)
        })
    };

    function roomsQuantitiesFilterFn(val: string, update: any) {
        if (val === '') {
            update(() => {
                filteredRoomsQuantities.value = Object.values(RoomsQuantity);
            })
            return
        }

        update(() => {
            const needle = val.toLowerCase()
            filteredRoomsQuantities.value = Object.values(RoomsQuantity).filter(v => v.toLowerCase().indexOf(needle) > -1)
        })
    };

    function bathroomsQuantitiesFilterFn(val: string, update: any) {
        if (val === '') {
            update(() => {
                filteredBathroomsQuantities.value = Object.values(BathroomsQuantity);
            })
            return
        }

        update(() => {
            const needle = val.toLowerCase()
            filteredBathroomsQuantities.value = Object.values(BathroomsQuantity).filter(v => v.toLowerCase().indexOf(needle) > -1)
        })
    };
</script>

<template>
    <div style="width: 80vw">

        <form class="q-pa-lg rounded-borders" @submit="onSubmit">
            <h4 class="q-py-lg">Add announcement</h4>

            <div style="display: flex; justify-content: space-between;">
                <q-select filled
                          use-input
                          input-debounce="0"
                          v-model="category"
                          :options="filteredCategories"
                          label="Category"
                          @filter="categoriesFilterFn"
                          style="flex: 1; margin-right: 10px;"
                          behavior="menu"
                          :error="!!categoryError"
                          :error-message="categoryError" />

                <q-select filled
                          use-input
                          input-debounce="0"
                          v-model="type"
                          :options="filteredTypes"
                          label="Type"
                          @filter="typesFilterFn"
                          style="flex: 1; margin-left: 10px;"
                          behavior="menu"
                          :error="!!typeError"
                          :error-message="typeError" />
            </div>

            <q-input v-model="name"
                     type="text"
                     label="Name"
                     :error="!!nameError"
                     :error-message="nameError"
                     style="margin: 10px;"/>

            <div style="display: flex; justify-content: space-between;">
                <q-input v-model="price"
                         type="number"
                         label="Price"
                         :error="!!priceError"
                         :error-message="priceError"
                         style="flex: 1; margin: 10px;" />

                <Transition>
                    <q-input v-model="rent"
                             type="number"
                             label="Rent"
                             :error="!!rentError"
                             :error-message="rentError"
                             v-if="type === HomeType.ForRent"
                             style="flex: 1; margin: 10px;" />
                </Transition>

            </div>
            <q-select filled
                      use-input
                      input-debounce="0"
                      v-model="city"
                      :options="filteredCities"
                      label="City"
                      @filter="citiesFilterFn"
                      behavior="menu"
                      :error="!!cityError"
                      :error-message="cityError" />

            <div style="display: flex; justify-content: space-between;">
                <q-input v-model="livingArea"
                         type="number"
                         label="Living area"
                         :error="!!livingAreaError"
                         :error-message="livingAreaError"
                         style="flex: 1; margin: 10px;" />

                <Transition>
                    <q-input v-model="lotArea"
                             type="number"
                             label="Lot area"
                             :error="!!lotAreaError"
                             :error-message="lotAreaError"
                             v-if="category === Category.House"
                             style="flex: 1; margin: 10px;" />
                </Transition>
            </div>

            <div style="display: flex; justify-content: space-between;">
                <q-select filled
                            use-input
                            input-debounce="0"
                            v-model="floor"
                            :options="filteredFloors"
                            label="Floor"
                            @filter="floorsFilterFn"
                            behavior="menu"
                            :error="!!floorError"
                            :error-message="floorError"
                            v-if="category === Category.Flat"
                            style="flex: 1; margin: 10px;" />
                
                <q-select filled
                            use-input
                            input-debounce="0"
                            v-model="floorsQuantity"
                            :options="filteredFloorsQuantities"
                            label="Floors quantity"
                            @filter="floorsQuantitiesFilterFn"
                            behavior="menu"
                            :error="!!floorsQuantityError"
                            :error-message="floorsQuantityError"
                            v-if="category === Category.House"
                            style="flex: 1; margin: 10px;" />
            </div>

            <q-checkbox v-model="hasFurniture" label="Furniture" style="padding-bottom: 20px;" />

            <q-select filled
                        use-input
                        input-debounce="0"
                        v-model="roomsQuantity"
                        :options="filteredRoomsQuantities"
                        label="Rooms quantity"
                        @filter="roomsQuantitiesFilterFn"
                        behavior="menu"
                        :error="!!roomsQuantityError"
                        :error-message="roomsQuantityError" />

            <q-select filled
                        use-input
                        input-debounce="0"
                        v-model="bathroomsQuantity"
                        :options="filteredBathroomsQuantities"
                        label="Bathrooms quantity"
                        @filter="bathroomsQuantitiesFilterFn"
                        behavior="menu"
                        :error="!!bathroomsQuantityError"
                        :error-message="bathroomsQuantityError" />

            <q-input v-model="description"
                        type="textarea"
                        label="Description"
                        :error="!!descriptionError"
                        :error-message="descriptionError"
                        style="margin: 10px;" />

            <div class="q-py-lg">
                <q-btn label="Add" type="submit" color="primary" />
            </div>
        </form>
    </div>
</template>