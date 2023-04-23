<template>
    <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
        <nav-tabs-card>
            <template slot="content">
                <span class="md-nav-tabs-title">Tasks:</span>
                <md-tabs class="md-success" md-alignment="left">
                    <md-tab id="tab-home" md-label="All Task" md-icon="list">
                        <div>
                            <md-table v-model="tasks" @md-selected="onSelect">
                                <md-table-row slot="md-table-row" slot-scope="{ item }" md-selectable="multiple"
                                    md-auto-select>
                                    <md-table-cell>{{ item.name }}</md-table-cell>
                                    <md-table-cell>{{ item.code }}</md-table-cell>
                                    <md-table-cell>{{ item.description }}</md-table-cell>
                                    <md-table-cell>
                                        <md-button class="md-just-icon md-simple md-primary">
                                            <md-icon>edit</md-icon>
                                            <md-tooltip md-direction="top">Edit</md-tooltip>
                                        </md-button>
                                        <md-button class="md-just-icon md-simple md-danger">
                                            <md-icon>close</md-icon>
                                            <md-tooltip md-direction="top">Close</md-tooltip>
                                        </md-button>
                                    </md-table-cell>
                                </md-table-row>
                            </md-table>
                        </div>
                    </md-tab>

                    <md-tab id="tab-pages" md-label="Doing" md-icon="code">
                        <div>
                            <md-table v-model="taskDoing" @md-selected="onSelect">
                                <md-table-row slot="md-table-row" slot-scope="{ item }" md-selectable="multiple"
                                    md-auto-select>
                                    <md-table-cell>{{ item.name }}</md-table-cell>
                                    <md-table-cell>{{ item.code }}</md-table-cell>
                                    <md-table-cell>{{ item.description }}</md-table-cell>
                                    <md-table-cell>
                                        <md-button class="md-just-icon md-simple md-primary">
                                            <md-icon>edit</md-icon>
                                            <md-tooltip md-direction="top">Edit</md-tooltip>
                                        </md-button>
                                        <md-button class="md-just-icon md-simple md-danger">
                                            <md-icon>close</md-icon>
                                            <md-tooltip md-direction="top">Close</md-tooltip>
                                        </md-button>
                                    </md-table-cell>
                                </md-table-row>
                            </md-table>
                        </div>
                    </md-tab>

                    <md-tab id="tab-posts" md-label="Done" md-icon="done_all">
                        <div>
                            <md-table v-model="taskDone" @md-selected="onSelect">
                                <md-table-row slot="md-table-row" slot-scope="{ item }" md-selectable="multiple"
                                    md-auto-select>
                                    <md-table-cell>{{ item.name }}</md-table-cell>
                                    <md-table-cell>{{ item.code }}</md-table-cell>
                                    <md-table-cell>{{ item.description }}</md-table-cell>
                                    <md-table-cell>
                                        <md-button class="md-just-icon md-simple md-primary">
                                            <md-icon>edit</md-icon>
                                            <md-tooltip md-direction="top">Edit</md-tooltip>
                                        </md-button>
                                        <md-button class="md-just-icon md-simple md-danger">
                                            <md-icon>close</md-icon>
                                            <md-tooltip md-direction="top">Close</md-tooltip>
                                        </md-button>
                                    </md-table-cell>
                                </md-table-row>
                            </md-table>
                        </div>
                    </md-tab>
                </md-tabs>
            </template>
        </nav-tabs-card>
    </div>
</template>
<script>
import axios from 'axios';
import {
    NavTabsCard,
} from "@/components";
export default {
    components: {
        NavTabsCard,
    },
    data() {
    return {
      selected: [],
      tasks: [],
      taskDoing: [],
      taskDone: [],
    };
  },
  methods: {
    onSelect: function (items) {
      this.selected = items;
    },
    // onAll(){
    //     this.tasks = this.created();
    // },
    // onDoing(){
    //     this.tasks = this.tasks.filter(x => x.status == 1);
    //     console.log(this.tasks);
    //     debugger;
    // },
    // onDone(){
    //     this.tasks = this.tasks.filter(x => x.status == 2);
    // }
  },
  created() {
        const userId = this.$route.params.userId;
        const status = this.$route.params.status;
        axios.get(`http://localhost:8080/user/gettaskbyuser?userId=` + userId + `&status=` + status)
            .then(response => {
                this.tasks = response.data.data;
                this.taskDoing = this.tasks.filter(x => x.status == 1);
                this.taskDone = this.tasks.filter(x => x.status == 2);
            })
            .catch(e => {
                console.log("error");
            })
    },
};
</script>