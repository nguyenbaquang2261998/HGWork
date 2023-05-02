<template>
    <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
        <nav-tabs-card>
            <template slot="content">
                <span class="md-nav-tabs-title">Tasks:</span>
                <md-tabs class="md-success" md-alignment="left">
                    <md-tab id="tab-home" md-label="All Task" md-icon="list">
                        <div>
                            <md-table v-model="tasks" @md-selected="onSelect">
                                <md-table-row slot="md-table-row" slot-scope="{ item }">
                                    <md-table-cell>{{ item.name }}</md-table-cell>
                                    <md-table-cell>{{ item.code }}</md-table-cell>
                                    <md-table-cell>{{ item.description }}</md-table-cell>
                                    <md-table-cell v-if="item.status == 0">Backlog</md-table-cell>
                                    <md-table-cell v-if="item.status == 1">Doing</md-table-cell>
                                    <md-table-cell v-if="item.status == 2">Done</md-table-cell>
                                    <md-table-cell v-if="item.status == 3">Pending</md-table-cell>
                                    <md-table-cell v-if="item.status == 4">Canceled</md-table-cell>
                                    <md-table-cell>
                                        <md-button @click="toUpdate(item.id)" class="md-just-icon md-simple md-primary">
                                            <md-icon>edit</md-icon>
                                            <md-tooltip md-direction="top">Edit</md-tooltip>
                                        </md-button>
                                    </md-table-cell>
                                </md-table-row>
                            </md-table>
                        </div>
                    </md-tab>

                    <md-tab id="tab-pages" md-label="Doing" md-icon="code">
                        <div>
                            <md-table v-model="taskDoing" @md-selected="onSelect">
                                <md-table-row slot="md-table-row" slot-scope="{ item }">
                                    <md-table-cell>{{ item.name }}</md-table-cell>
                                    <md-table-cell>{{ item.code }}</md-table-cell>
                                    <md-table-cell>{{ item.description }}</md-table-cell>
                                    <md-table-cell>
                                        <md-button @click="toUpdate(item.id)" class="md-just-icon md-simple md-primary">
                                            <md-icon>edit</md-icon>
                                            <md-tooltip md-direction="top">Edit</md-tooltip>
                                        </md-button>
                                    </md-table-cell>
                                </md-table-row>
                            </md-table>
                        </div>
                    </md-tab>

                    <md-tab id="tab-posts" md-label="Done" md-icon="done_all">
                        <div>
                            <md-table v-model="taskDone" @md-selected="onSelect">
                                <md-table-row slot="md-table-row" slot-scope="{ item }">
                                    <md-table-cell>{{ item.name }}</md-table-cell>
                                    <md-table-cell>{{ item.code }}</md-table-cell>
                                    <md-table-cell>{{ item.description }}</md-table-cell>
                                    <md-table-cell>
                                        <md-button @click="toUpdate(item.id)" class="md-just-icon md-simple md-primary">
                                            <md-icon>edit</md-icon>
                                            <md-tooltip md-direction="top">Edit</md-tooltip>
                                        </md-button>
                                    </md-table-cell>
                                </md-table-row>
                            </md-table>
                        </div>
                    </md-tab>

                    <md-tab id="tab-pending" md-label="Pending" md-icon="pending">
                        <div>
                            <md-table v-model="taskPending" @md-selected="onSelect">
                                <md-table-row slot="md-table-row" slot-scope="{ item }">
                                    <md-table-cell>{{ item.name }}</md-table-cell>
                                    <md-table-cell>{{ item.code }}</md-table-cell>
                                    <md-table-cell>{{ item.description }}</md-table-cell>
                                    <md-table-cell>
                                        <md-button @click="toUpdate(item.id)" class="md-just-icon md-simple md-primary">
                                            <md-icon>edit</md-icon>
                                            <md-tooltip md-direction="top">Edit</md-tooltip>
                                        </md-button>
                                    </md-table-cell>
                                </md-table-row>
                            </md-table>
                        </div>
                    </md-tab>

                    <md-tab id="tab-canceled" md-label="Canceled" md-icon="cancel">
                        <div>
                            <md-table v-model="taskCancel" @md-selected="onSelect">
                                <md-table-row slot="md-table-row" slot-scope="{ item }">
                                    <md-table-cell>{{ item.name }}</md-table-cell>
                                    <md-table-cell>{{ item.code }}</md-table-cell>
                                    <md-table-cell>{{ item.description }}</md-table-cell>
                                    <md-table-cell>
                                        <md-button @click="toUpdate(item.id)" class="md-just-icon md-simple md-primary">
                                            <md-icon>edit</md-icon>
                                            <md-tooltip md-direction="top">Edit</md-tooltip>
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
      taskPending: [],
      taskCancel: [],
    };
  },
  methods: {
    onSelect: function (items) {
      this.selected = items;
    },
    toUpdate(taskId) {
            location.href = "http://localhost:8080/#/updatetask/" + taskId;
        }
  },
  created() {
        // const userId = this.$route.params.userId;
        const status = this.$route.params.status;
        const userId = localStorage.getItem('userIdLogin');
        axios.get(`http://localhost:8080/user/gettaskbyuser?userId=` + userId + `&status=` + status)
            .then(response => {
                this.tasks = response.data.data;
                this.taskDoing = this.tasks.filter(x => x.status == 1);
                this.taskDone = this.tasks.filter(x => x.status == 2);
                this.taskPending = this.tasks.filter(x => x.status == 3);
                this.taskCancel = this.tasks.filter(x => x.status == 4);
                console.log(response.data.data);
            })
            .catch(e => {
                console.log("error");
            })
    },
};
</script>