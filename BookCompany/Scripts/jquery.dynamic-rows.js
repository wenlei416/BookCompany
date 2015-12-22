; (function ($) {
    $.fn.ssdDynamicRows = function (options) {
        var settings = $.extend({
            eventType: 'click',

            classContainer: 'dynamicRows',
            classRow: 'row',

            classAddButton: 'dynamicAdd',
            classRemoveButton: 'dynamicRemove',

            classWarning: 'warning'
        }, options);


        var row = '.' + settings.classRow,
            add = '.' + settings.classAddButton,
            remove = '.' + settings.classRemoveButton,
            warning = '.' + settings.classWarning;

        function preventStop(event) {
            event.preventDefault();
            event.stopPropagation();
        }

        function dynamicAttributes(ins) {
            var inputs = ins.find(':input'),
                labels = ins.find('label'),
                spans = ins.find('span[data-valmsg-for]'),
                warnings = ins.find(warning);

            $.each(inputs, function (index, value) {
                //var name = $(this).prop('name').split(/[[]|]/),
                //    newName = name[0] + '[' + (parseInt(name[1], 10) + 1) + ']' + name[2],
                //    newId = name[0] + '_' + (parseInt(name[1], 10) + 1) + '__' + name[2];
                var name = $(this).prop('id').split('_'),
                    newName = name[0] + '[' + (parseInt(name[1], 10) + 1) + '].' + name[3],
                    newId = name[0] + '_' + (parseInt(name[1], 10) + 1) + '__' + name[3];

                $(this).prop('name', newName).prop('id', newId).val('');//��֤clone������û��Ĭ��ֵ
                //console.log('inputs  '+newName);
            });


            $.each(labels, function (index, value) {
                var forAttr = $(this).prop('for').split('_'),
                    newForAttr = forAttr[0] + '_' + (parseInt(forAttr[1], 10) + 1) + '__' + forAttr[3];
                $(this).prop('for', newForAttr).find('.warning').remove();
                //console.log('labels ' + forAttr);

            });

            $.each(spans, function (index, value) {
                var valmsg = $(this).attr('data-valmsg-for').split(/[[]|]/),
                    newValmsg = valmsg[0] + '[' + (parseInt(valmsg[1], 10) + 1) + ']' + valmsg[2];
                $(this).attr('data-valmsg-for', newValmsg);
                //console.log('spans '+newValmsg);

            });

            $.each(warnings, function (index, value) {
                $(this).remove();
            });

            return ins;

        }

        function dynamicTemplate(ins) {
            return dynamicAttributes(ins.closest(row).clone());
        }

        function dynamicAdd(instance) {
            instance.on(settings.eventType, add, function (event) {

                preventStop(event);
                //���this���ǵ�������Ӱ�ť
                var thisRow = $(this).closest(row),
                    newItem = dynamicTemplate(thisRow);
                //instance ������dynamicWrapper
                instance.find(add).hide();
                instance.append(newItem);
                instance.find(remove).show();
                //paperNeedLengthNo = paperNeedLengthNo + 1;
                //paperNeedLength.prop('value', paperNeedLengthNo);
            });

        }

        function dynamicAttributes2(allrows) {
            $.each(allrows, function (index, value) {
                var inputs = $(this).find(':input'),
                    labels = $(this).find('label'),
                    spans = $(this).find('span[data-valmsg-for]'),
                    warnings = $(this).find(warning);

                $.each(inputs, function (index2, value) {
                    //var name = $(this).prop('name').split(/[[]|]/),
                    //    newName = name[0] + '[' + index + ']' + name[2],
                    //    newId = name[0] + '_' + index + '__' + name[2];
                    var name = $(this).prop('id').split('_'),
                        newName = name[0] + '[' + index + '].' + name[3],
                        newId = name[0] + '_' + index + '__' + name[3];
                    $(this).prop('name', newName).prop('id', newId);
                });

                $.each(labels, function (index2, value) {
                    var forAttr = $(this).prop('for').split('_'),
                        newForAttr = forAttr[0] + '_' + index + '__' + forAttr[3];
                    $(this).prop('for', newForAttr);
                });

                $.each(spans, function (index2, value) {
                    var valmsg = $(this).attr('data-valmsg-for').split(/[[]|]/),
                        newValmsg = valmsg[0] + '[' + index + ']' + valmsg[2];
                    $(this).attr('data-valmsg-for', newValmsg);
                });

                $.each(warnings, function (index, value) {
                    $(this).remove();
                });
            });
        }

        function dynamicRemove(instance) {
            instance.on(settings.eventType, remove, function (event) {

                preventStop(event);

                var thisRow = $(this).closest(row);

                thisRow.fadeOut(200, function () {
                    $(this).remove();
                    var allItems = instance.children(row);
                    //��allItems�����е��и�������0��ʼ����
                    dynamicAttributes2(allItems);
                    allItems.last(row).find(add).show();
                    if (allItems.length < 2) {
                        allItems.last(row).find(remove).hide();
                    }
                });
            });
        }

        function setUp(instance) {
            instance.last(row).find(remove).hide();
        }

        return this.each(function () {
            setUp($(this));//������Ⱦ��ϣ�����ɾ��һ�еİ�ť�ģ�����Ϊֻ��һ�У����Բ�����ʾ���Ƴ�����this������dynamicWrapper
            dynamicAdd($(this));//�����¼�
            dynamicRemove($(this));//�����¼�
            dynamicAttributes2($(this));
        });
    }
}(jQuery));